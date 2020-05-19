#!/bin/sh

# ユーザー設定
wsName=my-monorepo

# 定数定義
cntName=Setupper
ionrepl=6.9.2.0
mountPath=$(pwd)/mount
ngrepl=9.1.6.0


# Docker の確認
if ! type "docker" > /dev/null; then
    echo "Please setup Docker"
    exit 1
fi


# Angular 構築
docker run -dit --rm --name=$cntName -v $mountPath:/home/mount tshion/angular-repl:$ngrepl
docker exec $cntName ng new --create-application=false --new-project-root='.' $wsName --skip-git --skip-install
docker exec $cntName sh -c "cp -r . ../mount"
docker kill --signal="KILL" $cntName

# Ionic 構築
docker run -dit --rm --name=$cntName -v $mountPath/$wsName:/home/worker tshion/ionic-repl:$ionrepl
docker exec $cntName yarn install
docker exec $cntName yarn ng generate library --prefix=lib lib --skip-install
docker exec $cntName yarn ng generate application --minimal --prefix=app --routing --style=css app --skip-install
docker exec $cntName yarn ng add @ionic/angular --project=app
docker exec $cntName ionic init --multi-app
docker exec $cntName sh -c "cd app && ionic init app --type=angular --default --project-id=app"
docker kill --signal="KILL" $cntName

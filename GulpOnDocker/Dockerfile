# ベースイメージの設定
FROM node:8.1.2

# 作業ディレクトリの整備
RUN mkdir -p /workspace
WORKDIR /workspace

# ビルド環境の整備
COPY ./gulpfile.js ./
COPY ./package.json ./
RUN npm install

# 公開ポートの設定
EXPOSE 8000
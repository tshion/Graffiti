# C 言語で逆ポーランド記法で入力された文字列の計算
c/run-calculator:
	cd ./$(@D) ; $(MAKE) $(@F)

# C 言語でHello World
c/run-hello-world:
	cd ./$(@D) ; $(MAKE) $(@F)

# C++ でHello World
cpp/run-hello-world:
	cd ./$(@D) ; $(MAKE) $(@F)

# C++ でマンデルブロ集合の算出
cpp/run-mandelbrot:
	cd ./$(@D) ; $(MAKE) $(@F)

# Java でマンデルブロ集合の算出
java/run-mandelbrot:
	cd ./$(@D) ; $(MAKE) $(@F)

# Xcode > MySavingReminders の初期セットアップ
xcode-init-my-saving-reminders:
	cd ./xcode/MySavingReminders ; $(MAKE) init

# Xcode > MySavingReminders のプロジェクトセットアップ
xcode-my-saving-reminders:
	cd ./xcode/MySavingReminders ; $(MAKE)

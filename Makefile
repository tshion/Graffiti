# C++ でHello World
cpp/run-hello-world:
	cd ./cpp ; $(MAKE) $(@F)

# C++ でマンデルブロ集合の算出
cpp/run-mandelbrot:
	cd ./cpp ; $(MAKE) $(@F)

# Java でマンデルブロ集合の算出
java-mandelbrot:
	cd ./java/mandelbrot ; $(MAKE)

# Xcode > MySavingReminders の初期セットアップ
xcode-init-my-saving-reminders:
	cd ./xcode/MySavingReminders ; $(MAKE) init

# Xcode > MySavingReminders のプロジェクトセットアップ
xcode-my-saving-reminders:
	cd ./xcode/MySavingReminders ; $(MAKE)

# C++ でマンデルブロ集合の算出
cpp-mandelbrot:
	cd ./cpp/mandelbrot ; $(MAKE)
	cd ./cpp/mandelbrot/bin ; ./main

# Java でマンデルブロ集合の算出
java-mandelbrot:
	cd ./java/mandelbrot ; $(MAKE)

# Xcode > MySavingReminders の初期セットアップ
xcode-init-my-saving-reminders:
	cd ./xcode/MySavingReminders ; $(MAKE) init

# Xcode > MySavingReminders のプロジェクトセットアップ
xcode-my-saving-reminders:
	cd ./xcode/MySavingReminders ; $(MAKE)

FLAGS ?= -O0
BUILD_DIR = ./build

all : clean main.out

main.out : main.cpp
	mkdir -p $(BUILD_DIR)
	g++ $(FLAGS) main.cpp -o $(BUILD_DIR)/main.out

clean :
	rm -rf $(BUILD_DIR)
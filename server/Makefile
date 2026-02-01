FLAGS ?= -O0
CXX ?= g++

BUILD_DIR = ./build

all : clean main.out

main.out : main.cpp
	mkdir -p $(BUILD_DIR)
	$(CXX) $(FLAGS) main.cpp -o $(BUILD_DIR)/main.out

clean :
	rm -rf $(BUILD_DIR)
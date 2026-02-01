CXX ?= g++
CXXFLAGS  ?= -O0

BUILD_DIR = ./build

.PHONY: all
all : clean createBuildDir main.out
	

main.out : main.cpp
	$(CXX) $(FLAGS) main.cpp -o $(BUILD_DIR)/main.out

clean :
	rm -rf $(BUILD_DIR)

createBuildDir:
	mkdir -p $(BUILD_DIR)

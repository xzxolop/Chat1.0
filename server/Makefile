CXX ?= g++
CXXFLAGS  ?= -O0

BUILD_DIR = ./build

.PHONY: all
all : clean createBuildDir main.out
	
main.o : main.cpp
	$(CXX) $(FLAGS) -c $^ -o $(BUILD_DIR)/$@

main.out: main.o
	$(CXX) $(FLAGS) $(BUILD_DIR)/$^ -o $(BUILD_DIR)/$@

.PHONY: clean
clean :
	rm -rf $(BUILD_DIR)

.PHONY: createBuildDir
createBuildDir:
	mkdir -p $(BUILD_DIR)

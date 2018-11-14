cmake_minimum_required(VERSION 3.1)

# TODO: Root directory CMakeLists.txt
project(MeetingCpp2018)

set(CMAKE_CXX_STANDARD 14)

option(MEETINGCPP2018_LINK_STATIC "Link SFML and other dependencies statically" OFF)

# TODO: More platform support
if(${MEETINGCPP2018_LINK_STATIC})
	set(SFML_STATIC_LIBRARIES TRUE)

	if(WIN32 AND MSVC)
		# Change all MSVC compiler flags to /MT
		foreach(flag CMAKE_CXX_FLAGS CMAKE_CXX_FLAGS_DEBUG CMAKE_CXX_FLAGS_RELEASE)
			if(${flag} MATCHES "/MD")
			string(REGEX REPLACE "/MD" "/MT" ${flag} "${${flag}}")
			endif()
		endforeach()
	endif()
endif()

find_package(SFML 2.5.1 COMPONENTS graphics)

add_executable(MainLoop MainLoop.cpp)
target_link_libraries(MainLoop sfml-graphics)

add_executable(Shapes Shapes.cpp)
target_link_libraries(Shapes sfml-graphics)

add_executable(SpritesTextures SpritesTextures.cpp)
target_link_libraries(SpritesTextures sfml-graphics)

add_executable(TextsFonts TextsFonts.cpp)
target_link_libraries(TextsFonts sfml-graphics)

add_executable(VertexArraysBuffers VertexArraysBuffers.cpp)
target_link_libraries(VertexArraysBuffers sfml-graphics)

# TODO: Install targets
# TODO: Resource copying
cmake_minimum_required(VERSION 3.21)
project(TeamMeeting LANGUAGES CXX)

option(TEAMMEETING_LINK_STATIC "Link SFML and other dependencies statically" OFF)

if(TEAMMEETING_LINK_STATIC)
	set(SFML_STATIC_LIBRARIES TRUE)
endif()

include(FetchContent)
FetchContent_Declare(SFML
	GIT_REPOSITORY https://github.com/SFML/SFML.git
	GIT_TAG 2.6.0)
FetchContent_MakeAvailable(SFML)

add_executable(MainLoop src/MainLoop.cpp)
target_link_libraries(MainLoop PRIVATE sfml-graphics)
target_compile_features(MainLoop PRIVATE cxx_std_17)

if(WIN32 AND NOT TEAMMEETING_LINK_STATIC)
	add_custom_command(TARGET MainLoop POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_RUNTIME_DLLS:CMakeSFMLProject> $<TARGET_FILE_DIR:CMakeSFMLProject> COMMAND_EXPAND_LISTS)
endif()

install(TARGETS MainLoop)

add_executable(Shapes src/Shapes.cpp)
target_link_libraries(Shapes PRIVATE sfml-graphics)
target_compile_features(Shapes PRIVATE cxx_std_17)

if(WIN32 AND NOT TEAMMEETING_LINK_STATIC)
	add_custom_command(TARGET Shapes POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_RUNTIME_DLLS:CMakeSFMLProject> $<TARGET_FILE_DIR:CMakeSFMLProject> COMMAND_EXPAND_LISTS)
endif()

install(TARGETS Shapes)

add_executable(SpritesTextures src/SpritesTextures.cpp)
target_link_libraries(SpritesTextures PRIVATE sfml-graphics)
target_compile_features(SpritesTextures PRIVATE cxx_std_17)

if(WIN32 AND NOT TEAMMEETING_LINK_STATIC)
	add_custom_command(TARGET SpritesTextures POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_RUNTIME_DLLS:CMakeSFMLProject> $<TARGET_FILE_DIR:CMakeSFMLProject> COMMAND_EXPAND_LISTS)
endif()

install(TARGETS SpritesTextures)

add_executable(TextsFonts src/TextsFonts.cpp)
target_link_libraries(TextsFonts PRIVATE sfml-graphics)
target_compile_features(TextsFonts PRIVATE cxx_std_17)

if(WIN32 AND NOT TEAMMEETING_LINK_STATIC)
	add_custom_command(TARGET TextsFonts POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_RUNTIME_DLLS:CMakeSFMLProject> $<TARGET_FILE_DIR:CMakeSFMLProject> COMMAND_EXPAND_LISTS)
endif()

install(TARGETS TextsFonts)

add_executable(VertexArraysBuffers src/VertexArraysBuffers.cpp)
target_link_libraries(VertexArraysBuffers PRIVATE sfml-graphics)
target_compile_features(VertexArraysBuffers PRIVATE cxx_std_17)

if(WIN32 AND NOT TEAMMEETING_LINK_STATIC)
	add_custom_command(TARGET VertexArraysBuffers POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_RUNTIME_DLLS:CMakeSFMLProject> $<TARGET_FILE_DIR:CMakeSFMLProject> COMMAND_EXPAND_LISTS)
endif()

install(TARGETS VertexArraysBuffers)

install(DIRECTORY res .)
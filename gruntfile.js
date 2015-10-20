/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {

    grunt.initConfig({
        sass: {                          
            dist: {                           
                options: {                      
                    style: 'expanded'
                },
                files: [
                    {
                        "expand": true,
                        "src": ["wwwroot/Styles/*.scss"],
                        "dest": "wwwroot/Styles", // or "<%= src %>" for output to the same (source) folder
                        "ext": ".css"
                    }
                ]
            }
        },
        "watch": {
            "sass": {
                "files": ["wwwroot/Styles/*.scss"],
                "tasks": ["sass"],
                "options": {
                    "livereload": true
                }
            }
        }
    });

    grunt.loadNpmTasks("grunt-bower-task");
    grunt.loadNpmTasks("grunt-contrib-watch");
    grunt.loadNpmTasks("grunt-contrib-sass");


};
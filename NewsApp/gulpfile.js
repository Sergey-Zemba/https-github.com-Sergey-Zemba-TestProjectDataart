/// <binding BeforeBuild='default, movejs, movecss' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var bower = require('gulp-bower');

gulp.task('default', function () {
    return bower();
});

var config = {
    jssrc: [
        './bower_components/jquery/dist/jquery.js',
        './bower_components/bootstrap/dist/js/bootstrap.js',
        './bower_components/angular/angular.js',
        './bower_components/angular-animate/angular-animate.js',
        './bower_components/angular-sanitize/angular-sanitize.js',
        './bower_components/angular-cookies/angular-cookies.js',
        './bower_components/angular-bootstrap/ui-bootstrap-tpls.js'
    ],
    csssrc: './bower_components/bootstrap/dist/css/bootstrap.css'
};
gulp.task('movejs', function() {
    return gulp.src(config.jssrc).pipe(gulp.dest('./scripts'));
});
gulp.task('movecss', function () {
    return gulp.src(config.csssrc).pipe(gulp.dest('./content'));
});
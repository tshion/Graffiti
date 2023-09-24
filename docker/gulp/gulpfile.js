var gulp = require('gulp');

var fromPath = './app/source/*';
var toPath = './app/wwwroot';

gulp.task('copy', function () {
    gulp
        .src([
            fromPath
        ])
        .pipe(gulp.dest(toPath));
});

gulp.task('watch', ['copy'], function () {
    gulp.watch(fromPath,
        [
            'copy'
        ]);
});
/// <reference path="../library/jquery/jquery.d.ts" />

$(document).ready(function () {
    var videos = $(".video");

    console.log(videos);

    videos.mousemove(function (event) {
        var offset = $(this).offset();
        var w2 = $(this).width() / 2;
        var h2 = $(this).height() / 2;

        var x = event.pageX - offset.left;
        var y = event.pageY - offset.left;

        var rotateY = -(x - w2) / w2 * 10;
        var rotateX = -(y - w2) / w2 * 10;

        $(this).css("transform", "rotateX(" + rotateX + "deg) rotateY(" + rotateY + "deg)");

        var theta = Math.atan2(rotateX, rotateY);
        var angle = theta * 180 / Math.PI + 90;
        $(this).find(".shine").css('background', 'linear-gradient(' + angle + 'deg, rgba(255,255,255,' + event.pageY / h2 / 4 + ') 0%,rgba(255,255,255,0) 80%)');
    });

    videos.mouseout(function (event) {
        $(this).css("transform", "rotateX(0deg) rotateY(0deg)");
        $(this).find(".shine").css('background', "linear-gradient(135deg, rgba(255, 255, 255, 0.5) 0%, rgba(255, 255, 255, 0) 60%);");
    });
});
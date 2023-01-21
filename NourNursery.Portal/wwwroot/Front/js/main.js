$(document).ready(function () {  

    $(".tabs ul li:first").addClass("active");
    $(".list-tab").hide();
    $(".list-tab:first").show();
    $(".tabs ul li").on("click", function () {
        $(".tabs ul li").removeClass("active");
        $(this).addClass("active");
        $(".list-tab").hide();
        $($(this).data("b")).fadeIn();

    });
    
    $('.bar').click(function(){
        $("nav").toggleClass("open");
        $("body").toggleClass("i-open");
    })
   
  

    $(".swiper-pagination-bullet").html(" ");

    // window.scroll(function() {
    //   // if(window.pageYOffset > 200){
        
    //   //   console.log("class")
    //   // } else{
    //   //   console.log("not")

    //   // }
    //   alert()
    // });
    $(window).on('scroll', () => {
      var scrollTop = $(window).scrollTop()
      if (scrollTop > 300){ 
       $("nav").addClass("active")
      } else {
        $("nav").removeClass("active")

      }
    })


});

var swiper = new Swiper(".mySwiper", {
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
        renderBullet: function (index, className) {
          return '<span class="' + className + '">' + (index + 1) + "</span>";
        },
      },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
  });
  var swiper = new Swiper(".mySwiper1", {});







  var swiper = new Swiper(".mySwiper8", {
    spaceBetween: 10,
    slidesPerView: 3,
    freeMode: true,
    watchSlidesProgress: true,
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev"
    },
  });
  var swiper2 = new Swiper(".mySwiper2", {
    spaceBetween: 10,
  
    thumbs: {
      swiper: swiper
    }
  });

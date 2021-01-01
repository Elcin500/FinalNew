$(document).ready(function () {
    
 // header and footer 
    header();
    footer();

//Header functions
function header() {
    //Header functions
    let liLang = $('#lang');

    let liLangSpan = $('#lang > span');

    let liLangImg=$('.lang-img-main');

    let hidden = $(`#lang-div`);

    $(liLang).hover(function () {
    
        // console.log(hidden);
        $(hidden).removeClass('none')    
    }, function () {
        // out
        $(hidden).addClass('none');
    });

    
    let langs = $(`#lang-div a `);


    $.each(langs, function (index, element) { 
         $(element).click(function (e) { 
             e.preventDefault();
             

             let a=e.currentTarget;

             span = e.currentTarget.getElementsByTagName('span');
             img = e.currentTarget.getElementsByTagName('img');
             imgsrc=$(img).attr('src');

             $(liLangSpan).text($(span).text());

             $(liLangImg).attr('src', imgsrc);
             
         });
    });



  $('#dropdownMenu2').click(function (e) { 
      e.preventDefault();
      if($('.hidden-dropdown').hasClass('dropdown-display')){
        $('.hidden-dropdown').removeClass('dropdown-display');
      }
      else{
        $('.hidden-dropdown').addClass('dropdown-display');
      }
  });

  $.each($('.dropdown-menu-items'), function (index, insideMenuButtons) { 
    
     $(insideMenuButtons).find('button').click(function (e) { 
         e.preventDefault();
        //  console.log(e.currentTarget);
        let hiddenMenu= $(insideMenuButtons).find('div');
        if($(hiddenMenu).hasClass('dropdown-display')){
            $(hiddenMenu).removeClass('dropdown-display');
          }
          else{
            $(hiddenMenu).addClass('dropdown-display');
          }
         
     });

  });


  
  
$('.openNav').click(function (e) { 
  e.preventDefault();
  if(document.getElementById("mySidenav").style.width == 0 || document.getElementById("mySidenav").style.width == "0px"){

   document.getElementById("mySidenav").style.width = "270px";

   if ($('.overlay').css('display')=='none') {
       $('.overlay').css('display', 'block');
   }

  }
  else{
   document.getElementById("mySidenav").style.width = "0px";
   $('.overlay').css('display', 'none');
   
  }

});

$('.closebtn').click(function (e) { 
  e.preventDefault();
  document.getElementById("mySidenav").style.width = "0";
  $('.overlay').css('display', 'none');
 });
 
 
 
 $('.overlay').click(function (e) { 
     e.preventDefault();
     document.getElementById("mySidenav").style.width = "0px";
     $('.overlay').css('display', 'none');
 });


 if ($(window).width()>400 ) {

 $('.col-bottom ul').css('left', $(window).width()-405);
 $('.col-bottom ul #lang').css('margin-left','50px');
 $('.header-bottom .col-bottom .logo img').css('display','inherit');

   
 }

 if ($(window).width()<=400 ) {

  $('.col-bottom ul').css('left', $(window).width()-175);
  $('.col-bottom ul #lang').css('margin-left','0px');
  $('.header-bottom .col-bottom .logo img').css('display','none');
    
  }

 $(window).resize(function () { 

   if ($(window).width()>951) {
     if ($('#mySidenav').css('width')=='270px') {
      $('#mySidenav').css('width','0');
      $('.overlay').css('display','none');
     }
   }


   
 if ($(window).width()<=400 ) {

  $('.col-bottom ul').css('left', $(window).width()-175);
  $('.col-bottom ul #lang').css('margin-left','0px');

  $('.header-bottom .col-bottom .logo img').css('display','none');
    
  }

 if ($(window).width()>400 ) {

  $('.col-bottom ul').css('left', $(window).width()-405);
  $('.col-bottom ul #lang').css('margin-left','50px');
  $('.header-bottom .col-bottom .logo img').css('display','inherit');


  }

 });

}

// Footer
function footer() {
}





 

 ///////////////////////////////////////////////////////  scroll

$(document).scroll(function () {

    if ($(document).scrollTop() >= 200) {
        //$('.header-bottom').removeClass('scroll');
        $('.col-bottom').addClass('fixed-top');
    } else {
        //$('.header-bottom').addClass('scroll');
        $('.col-bottom').removeClass('fixed-top');

    }

});



///////////////////////////////////////   Main  /////////////////////////////

  ///// section first-carousel

  let homePhotos=$('.photo-carousel .item');

for (let index = 0; index < homePhotos.length; index++) {
  const element = homePhotos[index];

  let photo=$(element).attr('data-setbg');
  $(element).css("background-image",`url(${photo})`); 

}

  
$('.photo-carousel').owlCarousel({
  loop:true,
  nav:false,
  dots:false,
  autoplay:true,
  autoplayTimeout:3000,
  autoplayHoverPause:true,
  responsive:{
      0:{
          items:1
      },
      1000:{
          items:1
      }
  }
});


///////////////////////  section search

$('#search').change(function (e) { 
  e.preventDefault();
  console.log($('#search').val())
});


////////////////////////  section agents


$('.agents-carousel').owlCarousel({
  loop:true,
  nav:false,
  dots:false,
  autoplay:true,
  autoplayTimeout:3000,
  autoplayHoverPause:true,
  responsive:{
      0:{
          items:1
      },
      780:{
        items:2
      },
      1000:{
          items:3
      }
  }
});



////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////// Home Details ////////////////////////////////////////////////



let photo=$('.background-img').attr('data-setbg');
$('.background-img').css("background-image",`url(${photo})`);


//let detailsPhotos=$('.single-photo-carousel .item');


// for (let index = 0; index < detailsPhotos.length; index++) {
//   const element = detailsPhotos[index];

//   let photoSingle=$(element).attr('data-setbg');
//   $(element).css("background-image",`url(${photoSingle})`); 

// }



// $('.single-photo-carousel').owlCarousel({
// });






});


 //////////////////////////////////////////////////////////////////////
 
////////////////////    Carousels

$(document).ready(function() {

  var sync1 = $("#single-photo-carousel");
  var sync2 = $("#single-photo-carousel-down");

  var slidesPerPage = 5;


  if ($(window).width()<=340) {
    slidesPerPage = 1;
   }

  if ($(window).width()<=465 && $(window).width()>340 ) {
   slidesPerPage = 2;
  }

  if ($(window).width()<=750 && $(window).width()>465) {
     slidesPerPage = 3;
    }

    if ($(window).width()>=750 ) {
        slidesPerPage = 5;
       }
  
  var syncedSecondary = true;

  sync1.owlCarousel({
  loop:true,
  nav:true,
  dots:false,
  autoplay:false,
  autoplayTimeout:3000,
  autoplayHoverPause:true,
  responsive:{
      0:{
          items:1
      },
      1000:{
          items:1
      }
  },
  navText: ["<i class='fas fa-angle-left'></i>", "<i class='fas fa-angle-right'></i>"]
  }).on('changed.owl.carousel', syncPosition);

  sync2
      .on('initialized.owl.carousel', function() {
          sync2.find(".owl-item").eq(0).addClass("current");
      })
      .owlCarousel({
          items: slidesPerPage,
          dots: false,
          nav: true,
          smartSpeed: 200,
          slideSpeed: 500,
          slideBy: 2, //alternatively you can slide by 1, this way the active slide will stick to the first item in the second carousel
          responsiveRefreshRate: 100,
          navText: ["<i class='fas fa-angle-left'></i>", "<i class='fas fa-angle-right'></i>"]
      }).on('changed.owl.carousel', syncPosition2);

  function syncPosition(el) {
      //if you set loop to false, you have to restore this next line
      //var current = el.item.index;

      //if you disable loop you have to comment this block
      var count = el.item.count - 1;
      var current = Math.round(el.item.index - (el.item.count / 2) - .5);

      if (current < 0) {
          current = count;
      }
      if (current > count) {
          current = 0;
      }

      //end block

      sync2
          .find(".owl-item")
          .removeClass("current")
          .eq(current)
          .addClass("current");
      var onscreen = sync2.find('.owl-item.active').length - 1;
      var start = sync2.find('.owl-item.active').first().index();
      var end = sync2.find('.owl-item.active').last().index();

      if (current > end) {
          sync2.data('owl.carousel').to(current, 100, true);
      }
      if (current < start) {
          sync2.data('owl.carousel').to(current - onscreen, 100, true);
      }
  }

  function syncPosition2(el) {
      if (syncedSecondary) {
          var number = el.item.index;
          sync1.data('owl.carousel').to(number, 100, true);
      }
  }

  sync2.on("click", ".owl-item", function(e) {
      e.preventDefault();
      var number = $(this).index();
      sync1.data('owl.carousel').to(number, 300, true);
  });
});



///////////////////     img fullscreen 

// $('#single-photo-carousel .item img').click(function (e) { 
//     e.preventDefault();
//  $('.overlay').css('display', 'block');
    
//  console.log($('#single-photo-carousel .item img').css('margin'));
// });

// $('#single-photo-carousel .item img').click(function (e) { 
//     e.preventDefault();
//     e.stopPropagation();
// });

// $('.overlay').click(function (e) { 
//     e.preventDefault();
    
//     $('.overlay').css('display', 'none');
// });



$('.single-photo-fullscreen-carousel').owlCarousel({
    loop:true,
    nav:false,
    dots:false,
    responsive:{
        0:{
            items:1
        },
        1000:{
            items:1
        }
    }
  });
  

  (function () {
    'use strict'
  
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation')
  
    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
      .forEach(function (form) {
        form.addEventListener('submit', function (event) {
          if (!form.checkValidity()) {
            event.preventDefault()
            event.stopPropagation()
          }
  
          form.classList.add('was-validated')
        }, false)
      })
  })()



  //////////////////////////////////////////////////////////////////////////
  ///////////////////////      Contact            ////////////////////////////////

  $('.login-form ul li').click(function (e) { 
    e.preventDefault();

    let clas=$(e.currentTarget).attr('class');
    let currentLi=$(e.currentTarget);
    
    if ($(currentLi).hasClass('selected')) {
      return;
    }
    
    if ($(currentLi).hasClass('li-registr')) {
      $('.login-form ul .selected').removeClass('selected');
      $('.login-form ul .li-registr').addClass('selected');

      if ($('.registr-form-second').hasClass('d-none')) {
        $('.registr-form-second').removeClass('d-none');
      }
      if (!$('.registr-agent-form-third').hasClass('d-none')) {
        $('.registr-agent-form-third').addClass('d-none');
      }

      if (!$('.login-form-first').hasClass('d-none')) {
        $('.login-form-first').addClass('d-none');
      }

    }

    if ($(currentLi).hasClass('li-login')) {
      $('.login-form ul .selected').removeClass('selected');
      $('.login-form ul .li-login').addClass('selected');

      if (!$('.registr-form-second').hasClass('d-none')) {
        $('.registr-form-second').addClass('d-none');
      }
      if (!$('.registr-agent-form-third').hasClass('d-none')) {
        $('.registr-agent-form-third').addClass('d-none');
      }

      if ($('.login-form-first').hasClass('d-none')) {
        $('.login-form-first').removeClass('d-none');
      }

    }

    if ($(currentLi).hasClass('li-agent-registr')) {
      $('.login-form ul .selected').removeClass('selected');
      $('.login-form ul .li-agent-registr').addClass('selected');


      if (!$('.registr-form-second').hasClass('d-none')) {
        $('.registr-form-second').addClass('d-none');
      }
      if (!$('.login-form-first').hasClass('d-none')) {
        $('.login-form-first').addClass('d-none');
      }

      
      if ($('.registr-agent-form-third').hasClass('d-none')) {
        $('.registr-agent-form-third').removeClass('d-none');
      }

    }
    
  });





  //////////////////////////////////////////////////////////////////

  $('.single-home .like').click(function (e) { 
    e.preventDefault();
    
    if ($(e.currentTarget.children[0]).hasClass('fas fa-heart')) {
      $(e.currentTarget).html('<i class="far fa-heart"></i>');

    }
    else{
      $(e.currentTarget).html('<i style="color:#EA2027" class="fas fa-heart"></i>');
    }

    
    
  });
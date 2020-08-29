$(document).ready(function () {
    'use strict';
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });


    // Navbar Actions (Search Button)
    $('.navbar-light .navbar-nav .searchIcon').click(function () {
        $('.navbar-light .navbar-nav .search_form').toggleClass('hideOrShow');
    });

    // Navbar Actions (Checkout Button)
    $('.navbar-light .navbar-nav .checkoutIcon').click(function () {
        $('.navbar-light .navbar-nav .checkOutSection').toggleClass('showOrHideC');
    });


    // Collection Page ( Buy Product )
    $('.collectionPage .filtered .filtered_result .buyProdcut').on('click' ,function () {
        // Get Prodcut Info
        var product_img = $(this).children('img').attr('src'),
            product_name = $(this).children('div').children('p:first-of-type').text(),
            product_price = $(this).children('div').children('p:last-of-type').children('span').text(),
            prodcut_size = $(this).children('input.buyProdcut_size').val(),
            prodcut_quantity = $(this).children('input.buyProdcut_quantity').val(),
            product_id = $(this).children('input.buyProdcut_id').val();

        // Display Selected Product
        var addCart_prod_img = $('.buyProdcutPage .buyProdcutCart .addToCart img'),
            addCart_prod_AVAILABILITY = $('.buyProdcutPage .buyProdcutCart .addToCart .AVAILABILITY span'),
            addCart_prod_name = $('.buyProdcutPage .buyProdcutCart .addToCart h2'),
            addCart_prod_price = $('.buyProdcutPage .buyProdcutCart .addToCart h1 span'),
            addCart_prod_size = $('.buyProdcutPage .buyProdcutCart .addToCart .addToCart_sizes span.' + prodcut_size),
            addCart_prod_quantity = $('.buyProdcutPage .buyProdcutCart .addToCart .addToCart_qiantity span'),
            addCart_prod_totalPrice = $('.buyProdcutPage .buyProdcutCart .addToCart .total span'),
            addCart_prod_actionAdd = $('.buyProdcutPage .buyProdcutCart .addToCart a'),

            addCart_prod_productId = $('.buyProdcutPage .buyProdcutCart .addToCart input.addCart_ProdId'),
            addCart_prod_productPrice = $('.buyProdcutPage .buyProdcutCart .addToCart input.addCart_prodPrice'),
            addCart_prod_productQuantity = $('.buyProdcutPage .buyProdcutCart .addToCart input.addCart_prodQuan'),
            addCart_prod_productTotalPrice = $('.buyProdcutPage .buyProdcutCart .addToCart input.addCart_prodTotalp');
          

        addCart_prod_img.attr('src', product_img);
        addCart_prod_name.text(product_name);
        addCart_prod_price.text(product_price);
        // Reset Add Cart Labels every click to product
        addCart_prod_quantity.text(1);
        addCart_prod_totalPrice.text(product_price);
        addCart_prod_size.addClass("active");

        if (prodcut_quantity > 0) {
            addCart_prod_AVAILABILITY.text("in stock");
            addCart_prod_AVAILABILITY.css('color', '#00FB91');
            addCart_prod_actionAdd.removeClass("disabled");
        }

        else {
            addCart_prod_AVAILABILITY.text("out of stock");
            addCart_prod_AVAILABILITY.css('color', '#ff0018');
            addCart_prod_actionAdd.addClass("disabled");
        }

        // Set Form Inputs
        addCart_prod_productId.val(product_id);
        addCart_prod_productPrice.val(product_price);
        addCart_prod_productQuantity.val(1);
        addCart_prod_productTotalPrice.val(product_price);

        $('.buyProdcutPage').css("transform", "scale(1)");
    });

    $('.buyProdcutPage .buyProdcutCart i').click(function () {
        $('.buyProdcutPage').css("transform", "scale(0)");
        $('.buyProdcutPage .buyProdcutCart .addToCart .addToCart_sizes span').removeClass("active");
    });


    // Add to cart (Partial Page)
    $('.addToCart .addToCart_qiantity button:last-of-type').click(function () {
        var quantityValue = $('.addToCart .addToCart_qiantity span');
        var productPrice = $('.addToCart .productPrice span');
        var subTotal = $('.addToCart .total span');

        var addCart_prod_productQuantity = $('.buyProdcutPage .buyProdcutCart .addToCart input.addCart_prodQuan'),
            addCart_prod_productTotalPrice = $('.buyProdcutPage .buyProdcutCart .addToCart input.addCart_prodTotalp');

        var increment = parseInt(quantityValue.text()) + 1;
        var total = parseInt(productPrice.text()) * increment;

        subTotal.text(total);
        quantityValue.text(increment);

        // Set Form to Add cart
        addCart_prod_productQuantity.val(increment);
        addCart_prod_productTotalPrice.val(total);
    });

    $('.addToCart .addToCart_qiantity button:first-of-type').click(function () {
        var quantityValue = $('.addToCart .addToCart_qiantity span');
        var productPrice = $('.addToCart .productPrice span');
        var subTotal = $('.addToCart .total span');

        var addCart_prod_productQuantity = $('.buyProdcutPage .buyProdcutCart .addToCart input.addCart_prodQuan'),
            addCart_prod_productTotalPrice = $('.buyProdcutPage .buyProdcutCart .addToCart input.addCart_prodTotalp');

        var increment = parseInt(quantityValue.text()) - 1;

        //productUserQuantity = increment;
        
        if (increment <= 0) {
            quantityValue.text("1");

            // Set Form to Add cart
            addCart_prod_productQuantity.val(1);
            addCart_prod_productTotalPrice.val(productPrice.text());
        }

        else {
            quantityValue.text(increment);
            var total = parseInt(productPrice.text()) * increment;
            subTotal.text(total);

            // Set Form to Add cart
            addCart_prod_productQuantity.val(increment);
            addCart_prod_productTotalPrice.val(total);
        }
    });


    // Register Page
    $('.RegisterPage input[type="radio"]').click(function () {
        $(this).addClass('active').siblings().removeClass('active');
    });


    // Owal carousel
    $('.owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 3
            },
            1000: {
                items: 5
            }
        }
    })

    // Delete Prodcut from Admin
    $('.adminDeleteProd').click(function (e) {
        e.preventDefault();

        var deleteConfirm = confirm("Are you sure u want to delete ' " + $(this).data("name") + " ' ?");

        if (deleteConfirm === true) {

            $.ajax({
                type: "post",
                url: $(this).attr('href'),
                success: function () {
                    window.location.reload();
                }
            });

        } else {
            console.log("false");
        }
    });


    // Cart Page

    // Increment
    $('.cartPage .cartPage_prodQuan .productUserCartInc').on('click', function () {
        var productQuantity = $(this).next('span'),
            productCartID = $(this).prev('input').val(),
            productPrice = $(this).parent().parent().next('.totalPriceCell').children('span'),
            cartTotal = $('.cartTotal span');

        var increment = parseInt(productQuantity.text()) + 1;
        productQuantity.text(increment);

        $.ajax({
            type: "get",
            url: "/Home/UpdateCart",
            data: { id: productCartID, newQuantity: increment },
            dataType: "json",
            success: function (data) {
                productPrice.text(data.total);
                cartTotal.text(data.totalForUser);
            },
            error: function (err) {
                console.log(err);
            }
        });

    });
    // Decrement
    $('.cartPage .cartPage_prodQuan .productUserCartDec').on('click', function () {
        var productQuantity = $(this).prev('span'),
            productCartID = $(this).prev('span').prev('button').prev('input').val(),
            productPrice = $(this).parent().parent().next('.totalPriceCell').children('span'),
            cartTotal = $('.cartTotal span');

        var decrement = parseInt(productQuantity.text()) - 1;

        if (decrement > 0) {
            productQuantity.text(decrement);

            $.ajax({
                type: "get",
                url: "/Home/UpdateCart",
                data: { id: productCartID, newQuantity: decrement },
                dataType: "json",
                success: function (data) {
                    productPrice.text(data.total);
                    cartTotal.text(data.totalForUser);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }

        else {
            productQuantity.text(1);

        }

    });


    // Basket Partial View 
    $('.cartBasket .productInfo .productCount .productUserCartInc').on('click', function () {
        var productQuantity = $(this).next('span'),
            productCartID = $(this).prev('input').val(),
            productPrice = $(this).parent().prev('p').children('span'),
            cartTotal = $('.checkoutFooter p span');

        var increment = parseInt(productQuantity.text()) + 1;
        productQuantity.text(increment);

        $.ajax({
            type: "get",
            url: "/Home/UpdateCart",
            data: { id: productCartID, newQuantity: increment },
            dataType: "json",
            success: function (data) {
                //productPrice.text(data.total);
                cartTotal.text(data.totalForUser);
            },
            error: function (err) {
                console.log(err);
            }
        });
    })

    $('.cartBasket .productInfo .productCount .productUserCartDec').on('click', function () {
        var productQuantity = $(this).prev('span'),
            productCartID = $(this).prev('span ').prev('button').prev('input').val(),
            productPrice = $(this).parent().prev('p').children('span'),
            cartTotal = $('.checkoutFooter p span');

        var decrement = parseInt(productQuantity.text()) - 1;

        if (decrement > 0) {
            productQuantity.text(decrement);

            $.ajax({
                type: "get",
                url: "/Home/UpdateCart",
                data: { id: productCartID, newQuantity: decrement },
                dataType: "json",
                success: function (data) {
                   // productPrice.text(data.total);
                    cartTotal.text(data.totalForUser);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }

        else {
            productQuantity.text(1);
        }
    })

    $('.cartBasket .basktDelete').click(function () {
        var productCartId = $(this).data('prodid');

        var deleteConfirm = confirm("Are you sure u want to delete ?");

        if (deleteConfirm === true) {

            $.ajax({
                type: "post",
                url: "/Home/DeleteFromBasket/" + productCartId,
                success: function () {
                    window.location.reload();
                }
            });

        } else {
            console.log("false");
        }
    });
});
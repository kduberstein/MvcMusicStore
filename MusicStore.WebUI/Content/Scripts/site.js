/* Masked input filters */
$(function($)
{
    $(".zipcode").mask("99999-9999");
});

/* Shopping Cart Remove */
$(document).ready(function()
{
    $(".RemoveLink").click(function()
    {
        var cartItemToDelete = $(this).attr("data-cartItemId");
        var albumToRemove = $(this).attr("data-albumId");

        if (cartItemToDelete !== "")
        {
            clearUpdateMessage();

            $.ajax({
                    url: "/Cart/Remove",
                    type: "POST",
                    data: { "cartItemId": cartItemToDelete, "albumId": albumToRemove }
                })
                .success(function(data)
                {
                    $("#widget-row-" + data.DeleteId).fadeOut("slow");
                    $("#row-" + data.DeleteId).fadeOut("slow");

                    if (data.CartCount === 0)
                    {
                        $("#update-message").text(data.Message);
                        $("#cart-total").text(data.CartTotal);

                        $.ajax({
                            url: "/Cart/CartSummary",
                            dataType: "html",
                            type: "GET",
                            success: function(content)
                            {
                                $("#cart_render").html(content);
                            }
                        });

                        clearUpdateMessage();

                        $("#shopping-cart-table").append("<tr><td colspan=\"6\">Your shopping cart is empty!</td></tr>");
                    } else
                    {
                        $("#cart-widget-summary").text(data.CartCount + " item(s) - " + data.CartTotal);
                        $("#cart-widget-subtotal").text(data.CartTotal);
                        $("#cart-widget-total").text(data.CartTotal);
                        $("#update-message").text(data.Message);
                        $("#cart-total").text(data.CartTotal);
                    }
                });
        }
    });

    /* Shopping Cart Update Qty */
    $(".UpdateLink").click(function()
    {
        var cartItemToUpdate = $(this).attr("data-cartItemId");
        var albumToUpdate = $(this).attr("data-albumId");
        var newQty = 0;

        if ($("#" + $(this).attr("data-qty")).val().trim() !== "")
        {
            newQty = $("#" + $(this).attr("data-qty")).val();
        }

        if (cartItemToUpdate !== String.empty)
        {
            clearUpdateMessage();

            $.ajax({
                    url: "/Cart/Update",
                    type: "POST",
                    data: { "cartItemId": cartItemToUpdate, "albumId": albumToUpdate, "newQty": newQty }
                })
                .success(function(data)
                {
                    if (data.ItemQty === 0)
                    {
                        $("#row-" + data.DeleteId).fadeOut("slow");
                    }

                    $("#cart-widget-summary").text(data.CartCount + " item(s) - " + data.CartTotal);
                    $("#cart-widget-qty").text( "x " + data.ItemQty);
                    $("#cart-widget-subtotal").text(data.CartTotal);
                    $("#cart-widget-total").text(data.CartTotal);
                    $("#update-message").text(htmlDecode(data.Message));
                    $("#cart-total").text(data.CartTotal);
                });
        }
    });
});

/* Shopping Cart Helpers */
function clearUpdateMessage()
{
    $("#update-message").text("");
}

function htmlDecode(value)
{
    if (value)
    {
        return $("<div />").html(value).text();
    } else
    {
        return String.empty;
    }
}

if (typeof String.prototype.trim !== "function")
{
    var string = "";

    string.prototype.trim = function()
    {
        return this.replace(/^\s+|\s+$/g, "");
    };
}
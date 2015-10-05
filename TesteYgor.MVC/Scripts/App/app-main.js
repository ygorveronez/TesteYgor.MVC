//onload = SayHello;

$(document).ready(
    function ()
    {
        MainMenu();
        $('.cpf').mask('000.000.000-00');
        $('.cnpj').mask('00.000.000/0000-00');

    });

function MainMenu()
{

    $(function ()
    {
        $('#ul-menu li').hover(
            function ()
            {
                $('ul', this).slideDown(100);
            },
            function ()
            {
                $('ul', this).slideUp(100);
            }
        );
    });
}

function GetAjax(controller, action, parameters, display, delegate)
{
    $.ajax({
        type: 'GET',
        url: '/' + controller + '/' + action,
        data: parameters,
        beforeSend: function ()
        {
            $("#wait").css("display", "block");
        },
        success: function (response)
        {
            $("#wait").css("display", "none");
            $('#' + display).html(response);
            if (delegate != null)
            {
                delegate();
            }
        },
        failure: function (erro)
        {
            alert(erro);
        }
    });
}

function PostAjax(controller, action, formName, display, delegate)
{

    var form = $('#' + formName).closest("form");

    form.data("validator", null);
    form.data("unobtrusiveValidation", null);
    $.validator.unobtrusive.parse(form);

    if (form.validate().form())
    {
        $.ajax({
            type: 'POST',
            url: '/' + controller + '/' + action,
            data: form.serialize(),
            beforeSend: function ()
            {
                $('#wait').css("display", "block");
            },
            success: function (response)
            {

                $('#wait').css("display", "none");

                $('#' + display).html(response);

                if (delegate != null)
                {
                    delegate();
                }
            },
            failure: function (erro)
            {
                alert(erro);
            }
        });
    }

}

function ConfigStage()
{
    $('#stage-buttons').off();
    $('#stage-search').off();
    $('#stage-search').css("display", "none");
    $('#stage-buttons').css("display", "none");
    $('#stage-buttons button').css('display', 'none');
}

function SetIndexMode()
{
    $('#stage-search').css("display", "block");
}

function SetDetailsMode()
{
    $('#stage-buttons #stage-button-back').css('display', 'inline');
    $('#stage-buttons #stage-button-delete').css('display', 'inline');
    $('#stage-buttons #stage-button-edit').css('display', 'inline');
    $('#stage-buttons').css("display", "block");
}

function SetEditMode()
{
    $('#stage-buttons #stage-button-back').css('display', 'inline');
    $('#stage-buttons #stage-button-ok').css('display', 'inline');
    $('#stage-buttons').css("display", "block");
}


//checkBox Lists
/////////////////////////////////////////////////////////////
var items = {};

function GetItems(parameters, url, obj_name)
{

     $.ajax({
        url: url,
        type: 'GET',
        dataType: 'json',
        data: parameters,
        success: function (data)
        {
            items = data;
            displayItems(obj_name, items);
        },
        error: function (e)
        {
            alert("GetItems Erro");
            alert(e.responseText);
        }
    });
}

function displayItems(obj_name)
{

    lisItems = document.getElementById(obj_name);
    lisItems.innerHTML = "";

    lisItems.addEventListener("click", handleListClick, false);


    for (var i = 0; i < items.length; i++)
    {
        var li = createElement(i, items[i]);
        lisItems.appendChild(li);
    }
}

function createElement(index, item)
{

    var li = document.createElement("li");
    li.itemId = index;

    var checkbox = document.createElement('input');
    checkbox.type = "checkbox";

    if (item.Checked == true)
        checkbox.checked = "checked";

    checkbox.setAttribute("class", "lista");

    var label = document.createElement('label')

    label.appendChild(document.createTextNode(item.Nome));

    li.appendChild(checkbox);
    li.appendChild(label);

    return li;
}

function handleListClick(event)
{
    var isElement = event.srcElement.classList.contains("lista");

    if (isElement)
    {
        var listItem = event.srcElement.parentNode;
        items[listItem.itemId].Checked = event.srcElement.checked;

        var statusAnterior = items[listItem.itemId].Status;
        if (statusAnterior == 0)
        {
            items[listItem.itemId].Status = (event.srcElement.checked) ? 1 : 2;
        }
        else
        {
            items[listItem.itemId].Status = 0;
        }
    }

}

function SetItems(url, delegate, idParent)
{

    $.ajax({
        type: 'POST',
        traditional: true,
        url: url,
        dataType: 'json',
        data: JSON.stringify(items),
        contentType: 'application/json',
        beforeSend: function ()
        {
            $('#img-wait').css("display", "block");
            $('#img-menu-button').css("display", "none");
        },
        success: function (result)
        {
            $('#img-wait').css("display", "none");
            $('#img-menu-button').css("display", "block");
            if (delegate != null)
            {
                delegate();
            }
        },
        error: function (result)
        {
        }
    });

}

function LoginSaveLogin()
{
    $('#frmLogin').submit();
}

function AttachDatePicker(target)
{
    $(target).datepicker({
        altFormat: "dd/mm/yy",
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        nextText: 'Próximo',
        prevText: 'Anterior',
        selectOtherMonths: true
    });

    $(target).attr("data-val-date", "Data Inválida");
}
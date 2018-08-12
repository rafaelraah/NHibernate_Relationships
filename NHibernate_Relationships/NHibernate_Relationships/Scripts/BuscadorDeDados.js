function buscarData() {
    
    $.ajax(
        {
            type: "POST",
            url: "Other/TesteData",
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                $('#dataAtual').text(result);
            },
            error: function (req, status, error) {
                $('#dataAtual').text(error);
            }
        }
    )
}

function buscarPessoaAleatoria() {

    $('#buscarPessoaAleatoria').html("Aguarde...");

    $.ajax(
        {
            type: "POST",
            url: "Other/PessoaAleatoria",
            contentType: "application/json; charset=utf-8",
            success: function (result) {
              //  alert(result);
                $('#pessoaAleatoria').text(result.Nome);
            },
            error: function (req, status, error) {
                $('#pessoaAleatoria').text(error);
            }
        }
    ).always(function () {

        $('#buscarPessoaAleatoria').html('Buscar pessoa aleatoria');
    });


}
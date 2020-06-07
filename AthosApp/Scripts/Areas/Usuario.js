$.UsuarioAPI = function () {
    return {
        urlCriar: '/Usuario/Criar',
        urlEditar: '/Usuario/Editar',
        urlExcluir: '/Usuario/Excluir',

        Init: function () {
            this.Events.BindAll();
        },
        Events:
        {
            BindAll: function () {
                this.OnClickSalvarUsuario();
                this.OnClickEditarUsuario();
                this.OnClickDeleteUsuario();
            },
            OnClickSalvarUsuario: function () {
                $('#submitCondo').off().on('click', function () {
                    debugger;
                    var nome = $('#nomeUsu').val()
                    var email = $('#emailUsu').val()
                    var condominio = $('#condominioSelect selected')
                    var tipoUsuario = $('#divTipoUsu checked')
                    $.ajax({
                        url: $.UsuarioAPI.urlCriar,
                        contentType: 'application/json',
                        type: 'POST',
                        data: JSON.stringify({ nomeUsuario: nome, email: email, condominio: condominio, tipoUsuario: tipoUsuario }),
                        success: function () {
                            Alert("Usuario cadastrado com sucesso")
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            Alert("Houve um erro ao cadastrar um Usuario")
                        }
                    });
                });
            },
            OnClickEditarUsuario: function () {
                $('#editCondo').off().on('click', function () {
                    var id = this
                    window.location.href = $.ReportAPI.urlEditar + id;
                })
            },
            OnClickDeleteUsuario: function () {
                $('#removeCondo').off().on('click', function () {
                    var id = $('#id')
                    $.ajax({
                        url: $.UsuarioAPI.urlDelete,
                        contentType: 'application/json',
                        type: 'POST',
                        data: JSON.stringify({ idUsu: id}),
                        success: function () {
                            Alert("Usuario excluido com sucesso")
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            Alert("Houve um erro ao excluir um Usuario")
                        }
                    });
                })
            },
        },
        Methods:
        {
        }
    }
}
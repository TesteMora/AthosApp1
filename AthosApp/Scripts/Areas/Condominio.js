$.CondominioAPI = function () {
    return {

        Init: function () {
            this.Events.BindAll();
        },
        Events:
        {
            BindAll: function () {
                this.OnClickSalvarCondominio();
                this.OnClickEditarCondominio();
                this.OnClickDeleteCondominio();
            },
            OnClickSalvarCondominio: function () {
                $('#submitCondo').off().on('click', function () {
                    var id = $('#idCondo').val()
                    var nome = $('#nomeCondo').val()
                    var responsavel = $('#divResponsavel input')
                    var idresponsavel = -1
                    responsavel.each(function () {
                        if (this.checked) {
                            idresponsavel = this.value
                        }
                    })
                    var administradora = $('#divAdmin option')
                    var idadministradora = -1
                    administradora.each(function () {
                        if (this.attr("selected", "true")) {
                            idadministradora = this.value
                        }
                    })
                    debugger;
                    var data = JSON.stringify({ idCondo: id, nomeCondominio: nome, resposavel: idresponsavel, administradora: idadministradora })
                    
                    $.ajax({
                        url: '/Condominio/CriarCondominio',
                        contentType: 'application/json',
                        type: 'POST',
                        data: data,
                        success: function () {
                            Alert("Condominio cadastrado com sucesso")
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            Alert("Houve um erro ao cadastrar um Condominio")
                        }
                    });
                });
            },
            OnClickEditarCondominio: function () {
                $('#editCondo').off().on('click', function () {
                    var id = this
                    window.location.href = $.ReportAPI.urlEditar + id;
                })
            },
            OnClickDeleteCondominio: function () {
                $('#removeCondo').off().on('click', function () {
                    var id = $('#idCondo')
                    $.ajax({
                        url: $.CondominioAPI.urlDelete,
                        contentType: 'application/json',
                        type: 'POST',
                        data: JSON.stringify({ idCondo: id}),
                        success: function () {
                            Alert("Condominio excluido com sucesso")
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            Alert("Houve um erro ao excluir um Condominio")
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
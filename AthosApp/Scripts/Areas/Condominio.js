$.CondominioAPI = function () {
    return {

        Init: function () {
            this.Events.BindAll();
            
        },
        Events:
        {
            BindAll: function () {
                this.OnClickSalvarCondominio();
                this.OnClickSalvarAdministradora();
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
                    var administradora = $('#selectAdmin option')
                    var idadministradora = -1
                    administradora.each(function () {
                        if (this.selected == true) {
                            idadministradora = this.value
                        }
                    })
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
            OnClickSalvarAdministradora: function () {
                $('#submitAdmin').off().on('click', function () {
                    debugger;
                    var nome = $('#nomeCondo').val()
                    $.ajax({
                        url: '/Condominio/CreateAdm',
                        contentType: 'application/json',
                        type: 'POST',
                        data: JSON.stringify({ NomeAdministradora: nome}),
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

            popularDropdownAdministradora: function () {
                var dropdown = $("#selectAdmin");
                $.ajax({
                    url: '/Condominio/ListarAdm',
                    contentType: 'application/json',
                    type: 'GET',
                    data: JSON.stringify({ }),

                    success: function (data) {
                        var admins = $.parseJSON(data)
                        for (var i in admins) {
                            dropdown.append($("<option />").val(admins[i].Id).text(admins[i].NomeAdministradora));
                        }
                        //data.each(function () {
                        //    dropdown.append($("<option />").val(this.id).text(this.NomeAdministradora));
                        //});
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        Alert("Houve um erro ao cadastrar um Condominio")
                    }
                });
            }
        }
    }
}
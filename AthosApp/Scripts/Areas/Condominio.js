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
                this.OnClickAtualizarCondominio();
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
                    var nome = $('#nomeCondo').val()
                    $.ajax({
                        url: '/Administradora/CreateAdm',
                        contentType: 'application/json',
                        type: 'POST',
                        data: JSON.stringify({ NomeAdministradora: nome}),
                        success: function () {
                            alert("Condominio cadastrado com sucesso")
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert("Houve um erro ao cadastrar um Condominio")
                        }
                    });
                });
            },
            OnClickAtualizarCondominio: function () {
                $('#updateCondo').off().on('click', function () {
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
                        url: '/Condominio/Edit',
                        contentType: 'application/json',
                        type: 'POST',
                        data: data,
                        success: function () {
                            alert("Condominio atualizado com sucesso")
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert("Houve um erro ao atualizar um Condominio")
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
                            alert("Condominio excluido com sucesso")
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert("Houve um erro ao excluir um Condominio")
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
                    url: '/Administradora/ListarAdm',
                    contentType: 'application/json',
                    type: 'GET',
                    data: JSON.stringify({ }),

                    success: function (data) {
                        var admins = $.parseJSON(data)
                        for (var i in admins) {
                            dropdown.append($("<option />").val(admins[i].Id).text(admins[i].NomeAdministradora));
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Houve um erro ao cadastrar um Condominio")
                    }
                });
            },
            
            popularCondominios: function () {
                var condoDiv = $("#divCondos");
                $.ajax({
                    url: '/Condominio/ListarCondos',
                    contentType: 'application/json',
                    type: 'GET',
                    data: JSON.stringify({}),
                    success: function (data) {
                        var condos = $.parseJSON(data)
                        for (var i in condos) {
                            condoDiv.append($("<div class='row'><div class='col-md-3'><a class='btn btn-block btn-default' href='/Condominio/Editar/" + condos[i].Id + "'> Editar " + condos[i].NomeCondominio + "</a></div><div class='col-md-3'><a class='btn btn-block btn-danger' href='/Condominio/Delete/" + condos[i].Id + "'> Excluir " + condos[i].NomeCondominio + "</a></div></div><br/>"));
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Houve um erro ao cadastrar um Condominio")
                    }
                });
            },

             CarregarDados: function () {
                 var idcondo = parseInt(window.location.pathname.split("/")[3]);
                 var data = JSON.stringify({ 'id': idcondo });
                    $.ajax({
                     url: '/Condominio/GetCondominio',
                     contentType: 'application/json',
                     type: 'POST',
                     data: data,
                     success: function (data) {
                         var condos = $.parseJSON(data)
                         $('#idCondo').val(condos.Id)
                         $('#nomeCondo').val(condos.NomeCondominio)
                         var responsavel = $('#divResponsavel input')
                         responsavel.each(function () {
                             if (this.value == condos.Responsavel) {
                                 this.checked = true;
                             }
                         })
                         var administradora = $('#selectAdmin option')
                         administradora.each(function () {
                             if (condos.IdAdministradora == this.value) {
                                 this.selected = true
                                 
                             }
                         })
                     },
                     error: function (XMLHttpRequest, textStatus, errorThrown) {
                         alert("Houve um erro ao buscar um Condominio")
                     }
                 });
            }
        }
    }
}
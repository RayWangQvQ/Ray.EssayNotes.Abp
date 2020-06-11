$(function () {
    var l = abp.localization.getResource('BookStore');

    var createModal = new abp.ModalManager(abp.appPath + 'Book/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Book/EditModal');

    //分页列表：
    var dataTable = $('#BookTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(acme.bookStore.book.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            }
                        ]
                }
            },
            { data: "name" },
            { data: "type" },
            { data: "publishDate" },
            { data: "price" },
            { data: "creationTime" }
        ]
    }));


    //新建：
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#NewBookButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    //编辑：
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
});
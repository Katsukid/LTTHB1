// Thêm mới
var createEvent = {
     init: function () {
          createEvent.responseEvents();
     },
     responseEvents: function () {
          $('#createBtn').off('click').on('click', function(e) {
               e.preventDefault();
               var form = $("#create_form").serialize();
               $.ajax({
                    type: 'POST',
                    url: '/SINHVIENs/Create',
                    data: form,
                    dataType:'json',
                    success: function (check) {
                         if (check) {
                              alert("success");
                              $.ajax({
                                   type: 'GET',
                                   url: '/SINHVIENs/Index',
                                   dataType: 'html',
                                   success: function (partialView) {
                                        $('#index').html(partialView);
                                   }
                              })
                         }
                         else {
                              alert('Co loi, vui long kiem tra lai du lieu nhap');
                         }
                    }
               });
               return false;
          });
     }
};

// Xóa
var deleteEvent = {
     init: function () {
          deleteEvent.responseEvents();
     },
     responseEvents: function () {
          $('.delete').off('click').on('click', function (e) {
               e.preventDefault();
               var id = parseInt($(this).data("id"));
               $.ajax({
                    type: 'POST',
                    url: '/SINHVIENs/Delete',
                    data: {id: id},
                    dataType: 'json',
                    success: function (check) {
                         if (check) {
                              alert("success");
                              $.ajax({
                                   type: 'GET',
                                   url: '/SINHVIENs/Index',
                                   dataType: 'html',
                                   success: function (partialView) {
                                        $('#index').html(partialView);
                                   }
                              })
                         }
                         else {
                              alert('Co loi, vui long kiem tra lai du lieu nhap');
                         }
                    }
               });
               return false;
          });
     }
};

// Sửa
var editEvent = {
     init: function () {
          editEvent.responseEvents();
     },
     responseEvents: function () {
          $('.edit').off('click').on('click', function (e) {
               e.preventDefault();
               var id = parseInt($(this).data("id"));
               $.ajax({
                    type: 'GET',
                    url: '/SINHVIENs/Create',
                    data: { id: id },
                    dataType: 'html',
                    success: function (partialView) {
                         $("#infor").html(partialView);
                    }
               });
               return false;
          });
     }
}
var saveChangeEvent = {
     init: function () {
          saveChangeEvent.responseEvents();
     },
     responseEvents: function () {
          $('#saveChangeBtn').off('click').on('click', function (e) {
               e.preventDefault();
               var form = $("#create_form").serialize();
               var id = 1;
               $.ajax({
                    type: 'POST',
                    url: '/SINHVIENs/Edit',
                    data: form,
                    dataType: 'json',
                    success: function (check) {
                         if (check) {
                              alert("success");
                              $.ajax({
                                   type: 'GET',
                                   url: '/SINHVIENs/Index',
                                   dataType: 'html',
                                   success: function (partialView) {
                                        $('#index').html(partialView);
                                   }
                              })
                         }
                         else {
                              alert('Co loi, vui long kiem tra lai du lieu nhap');
                         }
                    }
               });
               return false;
          });
     }
}

// Hủy
var cancelEvent = {
     init: function () {
          cancelEvent.responseEvents();
     },
     responseEvents: function () {
          $('#cancelBtn').off('click').on('click', function (e) {
               e.preventDefault();
               $.ajax({
                    type: 'GET',
                    url: '/SINHVIENs/Create',
                    dataType: 'html',
                    success: function (partialView) {
                         $("#infor").html(partialView);
                    }
               });
               return false;
          });
     }
}

// Tìm kiếm
var searchEvent = {
     init: function () {
          searchEvent.responseEvents();
     },
     responseEvents: function () {
          $(".search").off("keyup").off("keydown").off("click").on("keyup click", function (e) {
               e.preventDefault();
               var form = $("#searchForm").serialize();
               $.ajax({
                    type: 'POST',
                    url: '/SINHVIENs/Search',
                    data: form,
                    dataType: 'html',
                    success: function (partialView) {
                         $('#index').html(partialView);
                    }
               });
               return false;
          });
     }
};


function FileCreate() {
    _this = this;

    this.ajaxFileUpload = "/File/Upload";

    this.init = function () {
        $('#UploadImage').fineUploader({
            request: {
                endpoint: _this.ajaxFileUpload
            },
        })
        .on('error', function (event, id, name, reason) { 
        })
        .on('complete', function (event, id, name, responseJSON) {
            $("#ImageOriginalPath").attr("value", responseJSON.data.filePath);
            $("#ImagePreviewPath").attr("value", responseJSON.data.filePreviewPath);
            $("#ImagePreview").attr("src", responseJSON.data.filePreviewPath);
        });
    }
}

var fileCreate = null;

$().ready(function () {
    fileCreate = new FileCreate();
    fileCreate.init();
});
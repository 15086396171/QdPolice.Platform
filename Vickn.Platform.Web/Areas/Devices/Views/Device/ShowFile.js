(function() {
  $(function () {
    var dataDictionaryService = abp.services.app.dataDictionary;

    dataDictionaryService.getDataDictionaryItemsByDicName({
      dicKey:"Forensics.Tag"
    }).done(function(result) {
      $.each(result.items,function(index, data) {
        console.log(index, data);
        $("#tag").append(' <li><a href= "javascript:;" data-value="'+data.value+'">' + data.displayName + '</a></li>');
      })
    })
  });
})()
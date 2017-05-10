﻿(function () {
    $(function () {

        var _cachingService = abp.services.app.caching;
        var _webLogService = abp.services.app.webLog;

        //Caching
        function clearCache(cacheName) {
            _cachingService.clearCache({
                id: cacheName
            }).done(function () {
                abp.notify.success("清除成功");
            });
        }

        function clearAllCaches() {
            _cachingService.clearAllCaches().done(function () {
                abp.notify.success("清除成功");
            });
        }

        $('.btn-clear-cache').click(function (e) {
            e.preventDefault();
            var cacheName = $(this).attr('data-cache-name');
            clearCache(cacheName);
        });

        $('#ClearAllCachesButton').click(function (e) {
            e.preventDefault();
            clearAllCaches();
        });

        //Web Logs
        function getWebLogs() {
            _webLogService.getLatestWebLogs({}).done(function (result) {
                var logs = getFormattedLogs(result.latesWebLogLines);
                $('#WebSiteLogsContent').html(logs);
                fixWebLogsPanelHeight();
            });
        }

        function downloadWebLogs() {
            _webLogService.downloadWebLogs({}).done(function (result) {
                downloadTempFile(result);
            });
        };

        function downloadTempFile(file) {
            location.href = abp.appPath + 'File/DownloadTempFile?fileType=' + file.fileType + '&fileToken=' + file.fileToken + '&fileName=' + file.fileName;
        };

        function getFormattedLogs(logLines) {
            var resultHtml = '';
            $.each(logLines, function (index, logLine) {
                resultHtml += '<span class="log-line">' + logLine
                .replace('DEBUG', '<span class="label label-default">DEBUG</span>')
                .replace('INFO', '<span class="label label-info">INFO</span>')
                .replace('WARN', '<span class="label label-warning">WARN</span>')
                .replace('ERROR', '<span class="label label-danger">ERROR</span>')
                .replace('FATAL', '<span class="label label-danger">FATAL</span>') + '</span>';
            });
            return resultHtml;
        }

        function fixWebLogsPanelHeight() {
            var windowHeight = $(window).height();
            var panelHeight = $('.full-height').height();
            var difference = windowHeight - panelHeight;
            var fixedHeight = panelHeight + difference;
            $('.full-height').css('height', (fixedHeight - 150) + 'px');
        }

        $('#DownloadAllLogsbutton').click(function (e) {
            e.preventDefault();
            downloadWebLogs();
        });

        $('#RefreshButton').click(function (e) {
            e.preventDefault();
            getWebLogs();
        });

        $(window).resize(function () {
            fixWebLogsPanelHeight();
        });

        getWebLogs();
    });
})();
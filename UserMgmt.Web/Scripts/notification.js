(function(){
    window.showNotification = function(message, type){
        // type: success, info, warning, error
        var colors = {
            success: '#28a745',
            info: '#17a2b8',
            warning: '#ffc107',
            error: '#dc3545'
        };

        var bg = colors[type] || colors.info;

        var container = document.getElementById('site-notification-container');
        if (!container){
            container = document.createElement('div');
            container.id = 'site-notification-container';
            container.style.position = 'fixed';
            container.style.top = '20px';
            container.style.right = '20px';
            container.style.zIndex = 10000;
            document.body.appendChild(container);
        }

        var toast = document.createElement('div');
        toast.className = 'site-toast';
        toast.style.background = bg;
        toast.style.color = '#fff';
        toast.style.padding = '12px 18px';
        toast.style.marginTop = '8px';
        toast.style.borderRadius = '4px';
        toast.style.boxShadow = '0 2px 6px rgba(0,0,0,0.2)';
        toast.style.fontFamily = 'Segoe UI, Arial, sans-serif';
        toast.style.cursor = 'pointer';
        toast.innerText = message;

        toast.onclick = function(){
            container.removeChild(toast);
        };

        container.appendChild(toast);

        // Auto-dismiss
        setTimeout(function(){
            if (toast.parentNode) container.removeChild(toast);
        }, 5000);
    };
})();

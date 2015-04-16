import React from 'react';
import MenuRoot from './menu/root';

$('.react-menu-info').each(function()
    {
        var id = $(this).attr('data-id');
        console.log();
        React.render(<MenuRoot uid={$(this).attr('data-id')} />, document.getElementById(id));
    });
import React from 'react';
import MenuRoot from './menu/root';

$('.react-menu').each(function()
    {
        var id = $(this).attr('id');
        React.render(<MenuRoot uid={id} />, document.getElementById(id));
    });
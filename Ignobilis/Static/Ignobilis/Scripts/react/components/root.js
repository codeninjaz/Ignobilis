import React from 'react';
import MenuRoot from './menu/root';

$('.react-menu').each(function()
    {
        let id = $(this).attr('id');
        let childrenFrom = $(this).attr('data-children-from');
        let pages = $(this).attr('data-pages');

        React.render(<MenuRoot uid={id} childrenFrom={childrenFrom} pages={pages} />, document.getElementById(id));
    });
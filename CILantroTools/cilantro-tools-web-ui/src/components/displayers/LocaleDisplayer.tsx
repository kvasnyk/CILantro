import * as React from 'react';

import { Locales } from '../../locales/Locales';
import LocalesType from '../../locales/LocalesType';

interface ILocaleDisplayerProps {
    localeKey: keyof LocalesType;
};

const LocaleDisplayer: React.StatelessComponent<ILocaleDisplayerProps> = (props) => {
    return (
        <span>{Locales[props.localeKey]}</span>
    );
};

export default LocaleDisplayer;
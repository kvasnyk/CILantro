import BoolElement from './BoolElement';
import ConstStringElement from './ConstStringElement';
import StringElement from './StringElement';

type AbstractInputOutputElement = ConstStringElement | StringElement | BoolElement;

export default AbstractInputOutputElement;

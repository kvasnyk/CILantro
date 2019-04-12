import BoolElement from './BoolElement';
import ConstStringElement from './ConstStringElement';
import IntElement from './IntElement';
import StringElement from './StringElement';

type AbstractInputOutputElement = ConstStringElement | StringElement | BoolElement | IntElement;

export default AbstractInputOutputElement;

import BoolElement from './BoolElement';
import ConstStringElement from './ConstStringElement';
import FloatElement from './FloatElement';
import IntElement from './IntElement';
import StringElement from './StringElement';

type AbstractInputOutputElement = ConstStringElement | StringElement | BoolElement | IntElement | FloatElement;

export default AbstractInputOutputElement;

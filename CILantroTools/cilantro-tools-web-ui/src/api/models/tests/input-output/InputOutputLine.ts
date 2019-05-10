import AbstractInputOutputElement from './elements/AbstractInputOutputElement';
import InputOutput from './InputOutput';

interface InputOutputLine {
	elements: AbstractInputOutputElement[];

	isRepeatBlock: boolean;
	repeatBlockInputOutput?: InputOutput;
	repeatBlockMin?: string;
	repeatBlockMax?: string;
}

export default InputOutputLine;

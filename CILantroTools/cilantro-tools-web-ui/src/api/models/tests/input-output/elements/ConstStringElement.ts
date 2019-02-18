import AbstractInputOutputElement from './AbstractInputOutputElement';

class ConstStringElement extends AbstractInputOutputElement {
	public value: string;

	constructor(value: string) {
		super();

		this.value = value;
	}
}

export default ConstStringElement;

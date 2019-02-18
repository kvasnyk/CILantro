import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';

type InputOutputElementParser = (elementString: string) => AbstractInputOutputElement;

const parseInputOutputElement: InputOutputElementParser = elementString => {
	const constStringRegExp = /^("([^".])+"|'([^'.])+')$/;
	if (elementString.match(constStringRegExp)) {
		return {
			type: 'ConstString',
			value: elementString.substring(1, elementString.length - 1)
		};
	}

	throw new Error('Element couldn\'t be parsed.');
};

export default parseInputOutputElement;

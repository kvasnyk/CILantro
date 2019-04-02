import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import StringElement from '../../api/models/tests/input-output/elements/StringElement';

type InputOutputElementParser = (elementString: string) => AbstractInputOutputElement;

const parseInputOutputElement: InputOutputElementParser = elementString => {
	const constStringRegExp = /^("([^".])+"|'([^'.])+')$/;
	if (elementString.match(constStringRegExp)) {
		return {
			type: 'ConstString',
			value: elementString.substring(1, elementString.length - 1)
		};
	}

	const stringRegExp = /^s .+$/;
	if (elementString.match(stringRegExp)) {
		const stringDefinition = elementString.substring(2, elementString.length);
		const stringArguments = stringDefinition.split(' ');

		const minLength = parseInt(stringArguments[0], 10);
		const maxLength = parseInt(stringArguments[1], 10);

		if (isNaN(minLength)) {
			throw new Error('StringElement minLength couldn\'t be parsed.');
		}

		if (isNaN(maxLength)) {
			throw new Error('StringElement maxLength couldn\'t be parsed.');
		}

		const result: StringElement = {
			type: 'String',
			name: 's',
			minLength,
			maxLength
		};

		for (let i = 2; i < stringArguments.length; i++) {
			const stringArgument = stringArguments[i];

			if (stringArgument === 'alpha') {
				result.isAlpha = true;
				continue;
			} else {
				throw new Error(`StringElement argument '${stringArgument}' couldn't be parsed.`);
			}
		}

		return result;
	}

	throw new Error('Element couldn\'t be parsed.');
};

export default parseInputOutputElement;

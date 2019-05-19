import translations from '../../translations/translations';

enum BaseLanguage {
	CIL = 0,
	CSharp = 1,
	FSharp = 2
}

export const BaseLanguageHelper = {
	getName: (lang?: BaseLanguage) => {
		switch (lang) {
			case BaseLanguage.CIL:
				return translations.shared.CIL;
			case BaseLanguage.CSharp:
				return translations.shared.CSharp;
			case BaseLanguage.FSharp:
				return translations.shared.FSharp;
			default:
				return translations.shared.noInfo;
		}
	}
};

export default BaseLanguage;

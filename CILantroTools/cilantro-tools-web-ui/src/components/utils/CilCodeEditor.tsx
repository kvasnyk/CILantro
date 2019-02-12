import 'brace';
import 'brace/ext/searchbox';
import 'brace/mode/csharp';
import 'brace/theme/github';

import React, { FunctionComponent } from 'react';
import AceEditor from 'react-ace';

interface CilCodeEditorProps {
	code: string;
}

const CilCodeEditor: FunctionComponent<CilCodeEditorProps> = props => {
	return (
		<AceEditor
			theme="github"
			mode="csharp"
			width="100%"
			fontSize={14}
			readOnly={true}
			value={props.code}
			maxLines={999}
			showPrintMargin={false}
			editorProps={{
				$blockScrolling: Infinity
			}}
		/>
	);
};

export default CilCodeEditor;

<p>
Cell based conditional formatting is implemented through 
<b>GridColumn.StyleField</b> property.
The following steps describe how it works in this sample:
<ol>
	<li>
	A CSS class ".negative_balance" with red background is defined 
	in the page;
	</li>
    <li>
    In addition to the regular data, "AccountNo" and "AccountBalance",
    an additional field is "BalanceStyle" is created in the data source.
    This field contains the CSS class to be applied to the balance cell.
    It's very easy to create such an additional data source using SQL
    statement, for example, instead of <i>"SELECT AccountNo, AccountBalance
    FROM Accounts"</i>, <i>"SELECT AccountNo, AccountBalance, 
    IIF(AccountBalance < 0, 'negative_balance', '') FROM Accounts"</i> can
    be used;
    </li>
    <li>
    The balance column's <b>StyleField</b> is set to "BalanceStyle".
    This instructs the Grid to populate the value in "BalanceStyle"
    to each cell's <b>Style</b> property;
    </li>
    <li>
    At runtime, the Grid applies each cell's <b>Style</b> property
    on each cell. If <b>Style</b> is empty, which is the case of a 
    positive balance, no additional style is applied;
    </li>
</ol>
</p>
<p>
The following steps describe how conditional formatting is implemented
in this sample:
<ol>
    <li>
    Two <b>GridItemStyleSet</b> objects are definied through the grid's
    <b>ItemStyles</b> property, one being the default style set, the other
    having a <b>StyleSetID</b> of "support". This second style set defines
    the blue color for posts originiated from "eo_support";
    </li>
    <li>
    While populating the grid, an additional field "StyleSet" is created
    based on "PostedBy". If "PostedBy" is "eo_support", then "StyleSet"
    is "support", otherwise it's empty;
    </li>
    <li>
    The grid's <b>StyleSetIDField</b> is set to "StyleSet", which instructs
    the grid's to store the value of "StyleSet" field created in step 2 
    into each grid item's <b>StyleSetID</b> property;
    </li>
    <li>
    At runtime, the grid checks each item's <b>StyleSetID</b> property, when 
    it encounters an item with <b>StyleSetID</b> set to "support", it searches
    for a <b>GridItemStyleSet</b> object with its <b>StyleSetID</b> matching
    this value. If a match is found, it uses styles defined in the matching 
    <b>GridItemStyleSet</b> for that item;
    </li>
</ol>
</p>
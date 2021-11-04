<p>
    To enable this feature, you must:
</p>
<ul>
    <li>
    Handle the SpellChecker's <b>CustomWord</b> event. Once you handle
    this event, the SpellChecker's <b>Add to Dictionary</b> button will
    be enabled. Clicking the button triggers your <b>CustomWord</b>
    handler;
    </li>
    <li>
    Inside the event handler you must call the <b>SpellChecker</b>'s
    <b>AddCustomWord</b> method to add the new word as a "global" or
    a "local" custom word. A "local" custom word applies to the current
    session only, while a "global" custom word applies to everyone;
    </li>
    <li>
    Optionally, you can save the custom word (EO.Web SpellChecker does not
    automatically save it for you) and call <b>AddCustomWord</b> again
    in your application's <b>Application_Start</b> handler (for global
    custom word) or <b>Session_Start</b> handler (for local custom word)
    to re-add them;        
    </li>
</ul>

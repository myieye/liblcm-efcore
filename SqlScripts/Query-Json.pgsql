    SELECT 
        "e".*, -- all columns
        "m", -- csv of all columns in 1 column
        "f", -- jsonb array element(s?)
        "f"->>'Text' -- jsonb property
        FROM "LexEntrys" as e
        LEFT JOIN "MoForms" AS m ON e."LexemeFormGuid" = m."Guid",
        jsonb_array_elements(m."Form") as f
        WHERE f->>'Text' LIKE '%zungunuk%' AND f->>'WritingSystem' LIKE '%se%';

SELECT
    "e".*
    FROM "LexEntrys" as e
    LEFT JOIN "MoForms" AS m ON e."LexemeFormGuid" = m."Guid"
    WHERE EXISTS(
        SELECT 1 FROM jsonb_array_elements(m."Form") as f
        WHERE f->>'Text' LIKE '%zung%' AND f->>'WritingSystem' LIKE '%se%');

SELECT * FROM "LexEntrys" as e LEFT JOIN "MoForms" AS m ON e."LexemeFormGuid" = m."Guid"
WHERE jsonb_path_exists(m."Form", '$ ? (@.Text like_regex "zung" && @.WritingSystem like_regex "se")');

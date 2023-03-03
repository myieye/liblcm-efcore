    SELECT 
        "e".*, -- all columns
        "m", -- csv of all columns in 1 column
        "f", -- jsonb array element(s?)
        "f"->>'Text' -- jsonb property
        FROM "Entries" as e
        LEFT JOIN "MoForm" AS m ON e."LexemeFormOAGuid" = m."Guid",
        jsonb_array_elements(m."Form") as f
        WHERE f->>'Text' LIKE '%zung%' AND f->>'WritingSystem' LIKE '%se%';

SELECT
    "e".*
    FROM "Entries" as e
    LEFT JOIN "MoForm" AS m ON e."LexemeFormOAGuid" = m."Guid"
    WHERE EXISTS(
        SELECT 1 FROM jsonb_array_elements(m."Form") as f
        WHERE f->>'Text' LIKE '%zung%' AND f->>'WritingSystem' LIKE '%se%');

SELECT * FROM "Entries" as e LEFT JOIN "MoForm" AS m ON e."LexemeFormOAGuid" = m."Guid"
WHERE jsonb_path_exists(m."Form", '$ ? (@.Text like_regex "zung" && @.WritingSystem like_regex "se")');

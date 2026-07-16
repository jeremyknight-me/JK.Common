## {{ Heading }}{{ InheritedSuffix }}

**Signature:** `{{ Signature }}`
{% if Summary != "" %}

**Summary:**
{{ Summary }}
{% endif %}
{% if HasParams %}

**Parameters:**
{%- for param in Params %}
- **{{ param.Name }}** — {{ param.Description }}
{%- endfor %}
{% endif %}
{% if HasReturns %}

**Returns:** {{ Returns }}
{% endif %}
{% if HasExceptions %}

**Exceptions:**
{%- for ex in Exceptions %}
- **{{ ex.Type }}**: {{ ex.Description }}
{%- endfor %}
{% endif %}
{% if HasExample %}

**Example:**
{{ Example }}
{% endif %}
{% if HasRemarks %}

**Remarks:** {{ Remarks }}
{% endif %}
{% for see in SeeAlso %}

- See: **{{ see }}**
{% endfor %}
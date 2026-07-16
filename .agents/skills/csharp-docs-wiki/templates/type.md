# {{ TypeName }}

**Namespace:** `{{ Namespace }}`

{{ Summary }}
{% for param in TypeParams %}

**Type Parameter:** `{{ param.Name }}` — {{ param.Description }}
{%- endfor %}
{% for ctor in Constructors %}

{{ ctor.Body }}
{%- endfor %}
{% for method in Methods %}

{{ method.Body }}
{%- endfor %}
{% for property in Properties %}

{{ property.Body }}
{%- endfor %}
{% for event in Events %}

{{ event.Body }}
{%- endfor %}
{% for field in Fields %}

{{ field.Body }}
{%- endfor %}
{% for nested in NestedTypes %}

{{ nested.Body }}
{%- endfor %}
{% if Remarks %}

{{ Remarks }}
{%- endif %}
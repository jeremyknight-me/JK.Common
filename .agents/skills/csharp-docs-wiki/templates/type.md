# {TypeName}

**Namespace:** `{Namespace}`

{Summary}

{#each TypeParams}
**Type Parameter:** `{Name}` — {Description}
{/each}

{#each Constructors}
### {DisplayName}

**Summary:** {Summary}

{#if HasParams}
**Parameters:**
{#each Params}
- **{Name}** — {Description}
{/each}
{/if}

{#if HasRemarks}
**Remarks:** {Remarks}
{/if}
{/each}

{#each Methods}
{Body}
{/each}

{#each Properties}
{Body}
{/each}

{#each Events}
{Body}
{/each}

{#each Fields}
{Body}
{/each}

{#each NestedTypes}
{Body}
{/each}

{#if Remarks}
{Remarks}
{/if}

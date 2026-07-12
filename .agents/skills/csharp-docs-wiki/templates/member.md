### {DisplayName}{InheritedSuffix}

**Signature:** `{Signature}`

**Summary:**
{Summary}

{#if HasParams}
**Parameters:**
{#each Params}
- **{Name}** — {Description}
{/each}
{/if}

{#if HasReturns}
**Returns:** {Returns}
{/if}

{#if HasExceptions}
**Exceptions:**
{#each Exceptions}
- **{Type}**: {Description}
{/each}
{/if}

{#if HasExample}
**Example:**
{Example}
{/if}

**Remarks:** {Remarks}

{#each SeeAlso}
- See: **{Value}**
{/each}

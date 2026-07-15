<<<<<<< HEAD
## {Heading}{InheritedSuffix}
=======
### {DisplayName}{InheritedSuffix}
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

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

<<<<<<< HEAD
{#if HasRemarks}
**Remarks:** {Remarks}
{/if}

{#each SeeAlso}
- See: **{Value}**
=======
**Remarks:** {Remarks}

{#each SeeAlso}
- See: **{.}**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
{/each}

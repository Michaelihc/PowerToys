# PowerToys AI Contributor Notes

Use the guidance in `AGENTS.md` for repo structure, build discipline, tests, and validation.

## Build Output

PowerToys builds can produce very large logs. Avoid dumping full build output into the terminal because it can make the shell and agent UI extremely slow.

- Prefer quiet build output and file loggers.
- Redirect noisy stdout/stderr to a local log file when needed.
- Inspect `build.<configuration>.<platform>.errors.log` first on failures.
- Summarize exit code, key errors/warnings, generated artifact paths, and log paths for the user.
- Only paste full build output when the user explicitly asks for it.

# Common Library

## FileSystemService

```c#
public AuthorizationRuleCollection GetAccessRules(string Path)

public async Task<AuthorizationRuleCollection> GetAccessRulesAsync(string Path)
```
## InstalledSoftwareService

```c#
public InstalledSoftwareService(string RemoteComputer, string Username, string Password)

public SortedSet<Software> GetInstalledSoftware()

public async Task<SortedSet<Software>> GetInstalledSoftwareAsync()
```
## LDAPService

```c#
public LDAPService(string Domain)

public IEnumerable<Principal> FindAllByName(string Name)

public async Task<Principal> FindOneByNameAsync(string Name)

public Principal FindOneByName(string Name)

public async Task<IEnumerable<Principal>> FindAllByNameAsync(string Name)

public PropertyCollection GetPropertyCollection(UserPrincipal User)

public async Task<PropertyCollection> GetPropertyCollectionAsync(UserPrincipal User)

public Principal GetFromAccessRule(AccessRule Rule)

public bool IsInheritedMemberOf(Principal Member, GroupPrincipal Group)

public async Task<bool> IsInheritedMemberOfAsync(Principal Member, GroupPrincipal Group)
```
## MailService

```c#
public MailService(string Server, int Port)

public void Send(string Sender, string Subject, string Body, IEnumerable<string> To)

public void AddAttachement(String Path)
```
## SharerightsService

```c#
public SharerightsService(string Domain)

public IEnumerable<DirectoryAccessRule> GetDirectoryAccessRules(string Directory)
```
## WMIService

```c#
public WMIService()

public WMIService(string Computername, string Username, string Password)

public IEnumerable<KeyValuePairList> GetWQLResults(string Query)

public async Task<IEnumerable<KeyValuePairList>> GetWQLResultsAsync(string Query)

public IEnumerable<string> GetWMIClasses()
```
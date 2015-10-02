# Unit Of Work
## Entity Framework shell



### Usage with [ninject] (http://www.ninject.org/)

```c#
	kernel.Bind<DbContext>().To<YourContext>().InRequestScope();
	kernel.Bind(typeof(IRepository<>)).To(typeof(BaseRepository<>)).InRequestScope();
```

```IRepository``` is a shell of ```DBSet<>``` and contains next methods:
```c#
	public interface IRepository<T>
	{
		T Get(Expression<Func<T, bool>> predicate);
		T FirstOrDefault(Expression<Func<T, bool>> predicate);
		IList<T> GetAll(Expression<Func<T, bool>> predicate);
		IList<T> GetAll();
		void Add(T entity);
		void Delete(T entity);
		IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate);
		IQueryable<T> GetQueryable();
		int Count(Expression<Func<T, bool>> predicate);
		int Count();
	}
```

### Usage with [Ninject.Extensions.Conventions] (https://github.com/ninject/ninject.extensions.conventions)
* Use ```IDependency``` interface to cast services to implemented interfaces
* Use ```ISelfDependency``` interface to cast helpers and services to self

```c#
	var assemblies = new Assembly[2];
	assemblies[0] = typeof(IDependency).Assembly;
	assemblies[1] = assembly; //your working assembly

	kernel.Bind(x => x.From(assemblies)
			.SelectAllClasses()
			.InheritedFrom<IDependency>()
			.BindAllInterfaces()
			.Configure(b => b.InRequestScope()));

	kernel.Bind(x => x.From(assemblies)
			.SelectAllClasses()
			.InheritedFrom<ISelfDependency>()
			.BindToSelf()
			.Configure(b => b.InRequestScope()));
```

### By the way, if you need to get context in specified type, just use ```GetContext<T>()```
```c#
	_unitOfWork.GetContext<YourContext>();
```
If it's not possible to cast to type, you'll get null reference exception

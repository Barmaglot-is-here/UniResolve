# UniResolve
Service locator с автоматической регистрацией зависимостей.

# Разрешение зависимостей
Для разрешения зависимостей используется следующий API:

```
var myService = Resolver.Request<ServiceType>();
```

# Регистрация зависимостей

## MonoRegistrationContainer
Является абстрактным классом, от которого необходимо унаследоваться, объявив все зависимости в виде полей.

Например:
```
public class UIRegistrationContainer : MonoRegistrationContainer
{
	[SerializeField]
	private IconLoadingService _iconLoadingService;
	[SerializeField]
	private NotificationService _notificationService;
	
	private TestService _testService;
	
	private void Awake()
	{
		_testService = new();
	}
}
```

После чего необходимо вызвать публичный метод Register():

```
public class EntryPoint : MonoBehaviour
{
	[SerializeField]
	private UIRegistrationContainer _registrationContainer;
	
	private void Awake()
	{
		_registrationContainer.Register();
	}
}
```

или

```
public class UIRegistrationContainer : MonoRegistrationContainer
{
	...
	
	private void Awake()
	{
		...
		
		Register();
	}
}
```

## SceneRegistrationContainer
Крепится к GameObject на сцене и регистрирует все компоненты являющиеся дочерними (за исключением компонентов движка)

Представим следующую иерархию:\
GameObject: SceneRegistrationContainer\
&emsp;|\
&emsp;GameObject: IconLoadingService\
&emsp;|\
&emsp;GameObject: NotificationService\
&emsp;|\
&emsp;GameObject: TestService
	
Где SceneRegistrationContainer прикреплён к root object в иерархии, а IconLoadingService, NotificationService и TestService прикреплены к дочерним объектам и будут зарегистрированы.

## Контейнеры с автоматической регистрацией
Так же существует MonoAutoRegistrationContainer и SceneAutoRegistrationContainer, самостоятельно регистрирующие зависимости в Awake()

## Самостоятельная регистрация зависимостей
Кроме того можно регистрировать зависимости самостоятельно:

```
Resolver.Register(service);
```

или


```
Resolver.RegisterRange(IEnumerable<object> services);
```